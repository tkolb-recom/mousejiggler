﻿#region header

// MouseJiggler - MainForm.cs
// 
// Created by: Alistair J R Young (avatar) at 2021/01/24 1:57 AM.

#endregion

#region using

using System;
using System.Windows.Forms;
using MouseJiggler.Properties;

#endregion

namespace MouseJiggler;

public partial class MainForm : Form
{
    /// <summary>
    ///     Constructor for use by the form designer.
    /// </summary>
    public MainForm()
        : this(jiggleOnStartup: false, minimizeOnStartup: false, zenJiggleEnabled: false, jigglePeriod: 1)
    {
    }

    public MainForm(bool jiggleOnStartup, bool minimizeOnStartup, bool zenJiggleEnabled, int jigglePeriod)
    {
        this.InitializeComponent();

        // Jiggling on startup?
        this.JiggleOnStartup = jiggleOnStartup;

        // Set settings properties
        // We do this by setting the controls, and letting them set the properties.

        this.cbMinimize.Checked = minimizeOnStartup;
        this.cbZen.Checked = miZenJiggle.Checked = zenJiggleEnabled;
        this.tbPeriod.Value = jigglePeriod;
    }

    public bool JiggleOnStartup { get; }

    private void MainForm_Load(object sender, EventArgs e)
    {
        if (this.JiggleOnStartup)
            this.cbJiggling.Checked = miJiggling.Checked = true;

        this.UpdateNotificationAreaText();
    }

    private void UpdateNotificationAreaText()
    {
        if (!this.cbJiggling.Checked)
        {
            this.niTray.Text = "Not jiggling the mouse.";
        }
        else
        {
            string? ww = this.ZenJiggleEnabled ? "with" : "without";
            this.niTray.Text = $"Jiggling mouse every {this.JigglePeriod} s, {ww} Zen.";
        }
    }

    private void cmdAbout_Click(object sender, EventArgs e)
    {
        new AboutBox().ShowDialog(owner: this);
    }

    #region Property synchronization

    private void cbSettings_CheckedChanged(object sender, EventArgs e)
    {
        this.panelSettings.Visible = this.cbSettings.Checked;
    }

    private void cbMinimize_CheckedChanged(object sender, EventArgs e)
    {
        this.MinimizeOnStartup = this.cbMinimize.Checked;
    }

    private void HandleZenChange(object sender, EventArgs e)
    {
        if (sender == cbZen)
        {
            this.ZenJiggleEnabled = miZenJiggle.Checked = this.cbZen.Checked;
        }
        else if (sender == miZenJiggle)
        {
            this.ZenJiggleEnabled = cbZen.Checked = this.miZenJiggle.Checked;
        }
    }

    private void tbPeriod_ValueChanged(object sender, EventArgs e)
    {
        this.JigglePeriod = this.tbPeriod.Value;
    }

    #endregion Property synchronization

    #region Do the Jiggle!

    protected bool Zig = true;

    private void HandleJigglingChange(object sender, EventArgs e)
    {
        if (sender == cbJiggling)
        {
            this.JiggleActive = miJiggling.Checked = this.cbJiggling.Checked;
        }
        else if (sender == miJiggling)
        {
            this.JiggleActive = cbJiggling.Checked = this.miJiggling.Checked;
        }

        this.UpdateNotificationAreaText();
    }

    private void jiggleTimer_Tick(object sender, EventArgs e)
    {
        if (this.ZenJiggleEnabled)
            Helpers.Jiggle(delta: 0);
        else if (this.Zig)
            Helpers.Jiggle(delta: 4);
        else //zag
            Helpers.Jiggle(delta: -4);

        this.Zig = !this.Zig;
    }

    #endregion Do the Jiggle!

    #region Minimize and restore

    private void MainForm_Resize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            this.MinimizeToTray();
        }
    }

    private void niTray_DoubleClick(object sender, EventArgs e)
    {
        this.RestoreFromTray();
    }

    private void MinimizeToTray()
    {
        this.Visible = false;
        this.ShowInTaskbar = false;
        this.niTray.Visible = true;
    }

    private void RestoreFromTray()
    {
        this.Visible = true;
        this.ShowInTaskbar = true;
        this.niTray.Visible = false;
        this.WindowState = FormWindowState.Normal;
    }

    #endregion Minimize and restore

    #region Settings property backing fields

    private int jigglePeriod;

    private bool jiggleActive;

    private bool minimizeOnStartup;

    private bool zenJiggleEnabled;

    #endregion Settings property backing fields

    #region Settings properties

    public bool JiggleActive
    {
        get => this.jiggleActive;
        set
        {
            this.jiggleTimer.Enabled = value;
            this.jiggleActive = value;
            Settings.Default.JiggleActive = value;
            Settings.Default.Save();
        }
    }

    public bool MinimizeOnStartup
    {
        get => this.minimizeOnStartup;
        set
        {
            this.minimizeOnStartup = value;
            Settings.Default.MinimizeOnStartup = value;
            Settings.Default.Save();
        }
    }

    public bool ZenJiggleEnabled
    {
        get => this.zenJiggleEnabled;
        set
        {
            this.zenJiggleEnabled = value;
            Settings.Default.ZenJiggle = value;
            Settings.Default.Save();
        }
    }

    public int JigglePeriod
    {
        get => this.jigglePeriod;
        set
        {
            this.jigglePeriod = value;
            Settings.Default.JigglePeriod = value;
            Settings.Default.Save();

            this.jiggleTimer.Interval = value * 1000;
            this.lbPeriod.Text = $"{value} s";
        }
    }

    #endregion Settings properties

    #region Minimize on start

    private bool firstShown = true;

    private void MainForm_Shown(object sender, EventArgs e)
    {
        if (this.firstShown && this.MinimizeOnStartup)
            this.MinimizeToTray();

        this.firstShown = false;
    }

    #endregion

    private void miShutdown_Click(object sender, EventArgs e)
    {
        Close();
    }
}