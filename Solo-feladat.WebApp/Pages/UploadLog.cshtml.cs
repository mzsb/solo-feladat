﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Solo_feladat.BLL.Interfaces;
using Solo_feladat.Model.Models;
using Solo_feladat.WebApp.Jobs;
using Solo_feladat.WebApp.Helper;

namespace Solo_feladat.WebApp.Pages
{
    [Authorize(Roles = "Pilot, Administrator")]
    public class UploadLogModel : PageModel
    {
        private readonly IFileManager fileManager;
        private IMapper mapper;
        private IFileProcessJob fileProcessJob;

        public string Message { get; set; }

        [BindProperty]
        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        public UploadLogModel(IFileManager fileManager, IMapper mapper, IFileProcessJob fileProcessJob)
        {
            this.fileManager = fileManager;
            this.mapper = mapper;
            this.fileProcessJob = fileProcessJob;
        }

        public async Task<ActionResult> OnPostUploadFile(List<IFormFile> formFiles)
        {
            foreach (var ff in formFiles)
            {
                if (!ff.FileName.Split('.').Last().Equals("igc"))
                {
                    Message = "Csak IGC-fájl tölthető fel";
                    return Page();
                }
            }

            var logFiles = new List<Solo_feladat.BLL.Dtos.File>();

            await logFiles.ConvertIFormFiles(formFiles, Guid.Parse(User.Identity.GetUserId()), FileType.Log);

            if (logFiles.Count > 0)
            {
                var mapped = mapper.Map<List<Solo_feladat.Model.Models.File>>(logFiles);

                bool result = await fileManager.InsertFilesAsync(mapped);

                if (result)
                {
                    fileProcessJob.Execute();
                    Message = "Sikeres fájlfeltöltés";
                }
                else
                {
                    Message = "Sikertelen fájlfeltöltés";
                }
            }
            return Page();
        }
    }
}