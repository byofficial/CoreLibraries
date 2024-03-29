﻿using HangFire.Web.Services;

namespace HangFire.Web.BackgroundJobs
{
    public class FireAndForgetJobs
    {
        public static void EmailSenderToUserJob(string userId, string message)
        {
            Hangfire.BackgroundJob.Enqueue<IEmailSender>(x => x.Sender(userId, message));
        }
    }
}