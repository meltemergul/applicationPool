using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using applicationPool.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace applicationPool.Controllers
{
    public class BMIController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CalculateBMI(float boy, float kilo)
        {
            var bmiModel = CreateBmiModel(boy,kilo);
            bmiModel.Sonuc = GetBmiCategory(bmiModel.VücutKitleEndeksi);

            return Json(bmiModel);
        }

        private BMIModel CreateBmiModel(float boy, float kilo)
        {
            var VücutKitleEndeksi = CalculateBmi(boy,kilo);

            return new BMIModel
            {
                Boy = boy,
                Kilo = kilo,
                VücutKitleEndeksi = VücutKitleEndeksi
            };
        }

        private float CalculateBmi(float boy, float kilo)
        {
            float heightInMeters = boy / 100;
            return kilo / (heightInMeters * heightInMeters);
        }

        private string GetBmiCategory(float VücutKitleEndeksi)
        {
            if (VücutKitleEndeksi < 18.5)
            {
                return "Az Kilolu";
            }
            if (VücutKitleEndeksi < 24.9)
            {
                return "Normal Kilolu";
            }
            if (VücutKitleEndeksi < 29.9)
            {
                return "Aşırı Kilolu";
            }
            return "Obez";
        }

    }
}

