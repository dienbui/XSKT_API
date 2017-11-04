using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XSKTDB;


namespace API.Controllers
{
    public class LottezyController : ApiController
    {
        public LottezyController()
        {

        }
        
        //[HttpGet]   
        //public IHttpActionResult GetListLottezy()
        //{
        //    IList<Prize> listPrize = null;
        //    using (var db = new XSKTDBDataContext())
        //    {
        //        db.DeferredLoadingEnabled = false;
               
        //        listPrize = db.Prizes.ToList<Prize>();
        //    }
        //    if (listPrize.Count == 0)
        //        return NotFound();
        //    else
        //    {
        //        Response response = new Response
        //        {
        //            code = 0,
        //            data = listPrize
        //        };
        //        return Ok(response);

        //    }
                
        //}


        /// <summary>
        /// Get_List_Lottezy
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("lottezies")]
        public IHttpActionResult Get_List_Lottezies()
        {
            IList<LocationPrize> listLocationPrize = null;
            Response resp = new Response();
            using (var db = new XSKTDBDataContext())
            {
                db.DeferredLoadingEnabled = false;

                listLocationPrize = db.LocationPrizes.ToList<LocationPrize>();
            }
            if (listLocationPrize.Count == 0)
            {
                resp.code = 1;
            }
            else
            {

                resp.code = 0;
                var view = new List<ViewModelLocationPrize>();
                foreach (var item in listLocationPrize)
                {
                    view.Add(
                        new ViewModelLocationPrize
                        {
                            lottezyId = item.ID.ToString(),
                            lottezyName = item.Name
                        }
                    );
                }
                resp.data = view;
               
              
            }
            return Ok(resp);
        }
        
        /// <summary>
        /// GET_LOTTEZY_BY_DATE
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("lottezy{lottezyId}")]
        public IHttpActionResult GetLottezyByDate(string date)
        {
            IList<Prize> listPrize = null;
           
            using (var db = new XSKTDBDataContext())
            {
                PrizeDetail detail = null;
                db.DeferredLoadingEnabled = false;
                try
                {
                    if (string.IsNullOrEmpty(date))
                    {
                        detail = db.PrizeDetails.OrderBy(x => x.DatePrize).ToList().FirstOrDefault();

                    }
                    else
                    {
                        string[] chuoi = date.Split('-');
                        DateTime dateTime = new DateTime(year: int.Parse(chuoi[0]), month: int.Parse(chuoi[1]), day: int.Parse(chuoi[2]));
                        

                    }
                   
                    

                }
                catch
                {
                    Response res = new Response();
                    res.code = 1;
                    return Ok(res);
                }
                
               
               
                listPrize = new List<Prize>();
                foreach (var item in tam)
                {
                    var luu = db.Prizes.Single(x => x.ID == item.ID);
                    listPrize.Add(luu);
                }
            }
            if (listPrize.Count == 0)
                return NotFound();
            else
            {
                return Ok(listPrize);
            }
               
        }

      

        
        [HttpPut]
        public IHttpActionResult UpdateLottezy([FromBody]Prize prize)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            Prize existingPrize = null;
            using (var db = new XSKTDBDataContext())
            {
                db.DeferredLoadingEnabled = false;
                existingPrize = db.Prizes.Where(s => s.ID == prize.ID).FirstOrDefault<Prize>();

                if (existingPrize != null)
                {
                    if (!String.IsNullOrEmpty(prize.FirstPrize))
                        existingPrize.FirstPrize = prize.FirstPrize;
                    if (!String.IsNullOrEmpty(prize.SecondPrize))
                        existingPrize.SecondPrize = prize.SecondPrize;
                    if (!String.IsNullOrEmpty(prize.ThirdPrize))
                        existingPrize.ThirdPrize = prize.ThirdPrize;
                    if (!String.IsNullOrEmpty(prize.FourthPrize))
                        existingPrize.FourthPrize = prize.FourthPrize;
                    if (!String.IsNullOrEmpty(prize.FifthPrize))
                        existingPrize.FifthPrize = prize.FifthPrize;
                    if (!String.IsNullOrEmpty(prize.SixthPrize))
                        existingPrize.SixthPrize = prize.SixthPrize;
                    if (!String.IsNullOrEmpty(prize.SeventhPrize))
                        existingPrize.SeventhPrize = prize.SeventhPrize;
                    if (!String.IsNullOrEmpty(prize.SpecialPrize))
                        existingPrize.SpecialPrize = prize.SpecialPrize;
                    db.SubmitChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok(existingPrize);
        }

    }
}
