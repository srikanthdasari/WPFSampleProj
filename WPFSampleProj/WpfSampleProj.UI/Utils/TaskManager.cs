using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfSampleProj.UI.Utils
{
    public class TaskManager
    {
        public virtual Task RunInBackground(Action action, CancellationTokenSource tokenSource=null)
        {
            return Task.Factory.StartNew(() =>
            {
                action();
            },
            tokenSource == null ? CancellationToken.None : tokenSource.Token,
            TaskCreationOptions.None,
            TaskScheduler.Default
            );
        }
    }
}
