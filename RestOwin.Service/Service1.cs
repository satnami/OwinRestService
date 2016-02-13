using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using RestOwin.Server;

namespace RestOwin.Service
{
    public partial class Service1 : ServiceBase
    {
        ConnectRest connection = new ConnectRest();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            connection.Start();
        }

        protected override void OnStop()
        {
            connection.Stop();
        }
    }
}
