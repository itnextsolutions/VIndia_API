
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VastraIndiaDAL
{
    public class SaveImageDAL
    {

        public async Task SaveImagesAsync(IFormFile formFile, string FileName, string FolderName)
        {
            try
            {
                //var formCollection = await Request.ReadFormAsync();
                var file = formFile;

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);
                if (file.Length > 0)
                {
                    var fileName = FileName;
                    //  var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(FolderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }

            catch (Exception ex)
            {
                //return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
