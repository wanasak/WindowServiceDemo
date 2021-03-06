﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowService
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer1 = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer();
            this.timer1.Interval = 30000;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
            timer1.Enabled = true;
            Library.Library.WriteErrorLog("Window service started");
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
            Library.Library.WriteErrorLog("Window service stopped");
        }

        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            Library.Library.WriteErrorLog("Timer ticked.");
        }
    }
}
