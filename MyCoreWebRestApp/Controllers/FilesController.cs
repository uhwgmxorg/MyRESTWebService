using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace MyCoreWebRestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        // GET api/files
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string[] files;
            int i = 0;

            try
            {
                files = Directory.GetFiles(@"..\TestData", "*.csv");
                foreach (var f in files)
                    files[i++] = Path.GetFileName(f);
            }
            catch (System.Exception ex)
            {
                files = new string[1];
                files[0] = ex.ToString();
            }

            return files;
        }

        // GET api/files/2
        [HttpGet("{param}")]
        public ActionResult<string> Get(string param)
        {
            try
            {
                int n;
                bool isNumeric = int.TryParse(param, out n);

                if (isNumeric)
                {
                    string[] files;
                    string contents;
                    files = Directory.GetFiles(@"..\TestData", "*.csv");
                    contents = System.IO.File.ReadAllText(files[n]);
                    return contents;
                }
                else
                {
                    Debug.WriteLine("command");
                    return param;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
