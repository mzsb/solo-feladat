﻿using Hangfire;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.BLL.Managers;
using Solo_feladat.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solo_feladat.WebApp.Jobs
{
    public class FileProcessJob : IFileProcessJob
    {
        private readonly SoloContext context;

        public FileProcessJob(SoloContext context)
        {
            this.context = context;
        }

        public void Execute()
        {
            IFileManager fileManager = new FileManager(context);

            RecurringJob.AddOrUpdate(() => fileManager.SaveDataFromFile(), Cron.Minutely);
        }
    }
}
