﻿using Nop.Services.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Nop.Plugin.Misc.Sendinblue.Services
{
    /// <summary>
    /// Represents a schedule task to synchronize contacts
    /// </summary>
    public class SynchronizationTask : IScheduleTask
    {
        #region Fields

        private readonly SendinblueManager _sendinblueEmailManager;

        #endregion

        #region Ctor

        public SynchronizationTask(SendinblueManager sendinblueEmailManager)
        {
            _sendinblueEmailManager = sendinblueEmailManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Execute task
        /// </summary>
        public async Task ExecuteAsync()
        {
            await _sendinblueEmailManager.SynchronizeAsync();
        }

        #endregion
    }
}