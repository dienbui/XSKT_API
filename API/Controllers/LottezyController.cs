using API.JWT;
using API.Models;
using API.Utils;
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
        TokenService tokenService = new TokenService();

        public LottezyController()
        {

        }

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
                            LottezyId = item.ID.ToString(),
                            LottezyName = item.Name
                        }
                    );
                }
                resp.data = view;
        }
         return Ok(resp);
    }

        /// <summary>
        /// GetLottezyByDate ko chua date
        /// </summary>
        /// <param name="lottezyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("lottezy/{lottezyId}")]
        public IHttpActionResult GetLottezyByDate(int lottezyId )
        {
            Prize kq = null;
            ViewModelPrize viewModelPrize = null;
            using (var db = new XSKTDBDataContext())
            {
                PrizeDetail detail = null;
                db.DeferredLoadingEnabled = false;
                try
                {

                    var DS = db.PrizeDetails.Where(x => x.LoctionPrizeId == lottezyId).ToList();
                    //lay ra ngay gan nhat
                    detail = DS.OrderByDescending(x => x.DatePrize).ToList().FirstOrDefault();
                    //lay ra giai ung voi ngay do
                    if (detail != null)
                    {
                        kq = db.Prizes.SingleOrDefault(x => x.ID == detail.PrizeId);
                        if (kq != null)
                        {
                            viewModelPrize = new ViewModelPrize(kq);
                            viewModelPrize.date = string.Format("{0}-{1}-{2}", detail.DatePrize.Value.Year, detail.DatePrize.Value.Month, detail.DatePrize.Value.Day);
                            viewModelPrize.LottezyId = detail.LoctionPrizeId.ToString();
                            viewModelPrize.LottezyName = db.LocationPrizes.SingleOrDefault(x => x.ID == detail.LoctionPrizeId).Name;
                        }

                    }


                }
                catch
                {
                    Response res = new Response();
                    res.code = 1;
                    return Ok(res);
                }

                if (kq == null)
                    return Ok(new Response
                    {
                        code = 1
                    });
                else
                {
                    return Ok(new Response
                    {
                        code = 0,
                        data = viewModelPrize
                    }
                        );
                }

            }
        }


        [HttpGet]
        [Route("lottezy/{lottezyId}")]
        public IHttpActionResult GetLottezyByDate(int lottezyId, [FromUri]string date)
        {
            Prize kq = null;
            ViewModelPrize viewModelPrize = null;
            using (var db = new XSKTDBDataContext())
            {
                PrizeDetail detail = null;
                db.DeferredLoadingEnabled = false;
                try
                {
                    if (string.IsNullOrEmpty(date))
                    {

                        //var DS = db.PrizeDetails.Where(x => x.LoctionPrizeId == lottezyId).ToList();
                        ////lay ra ngay gan nhat
                        //detail = DS.OrderBy(x => x.DatePrize).ToList().FirstOrDefault();
                        ////lay ra giai ung voi ngay do
                        //if (detail != null)
                        //    kq = detail.Prize;

                    }
                    else
                    {
                        string[] chuoi = date.Split('-');
                        DateTime dateTime = new DateTime(year: int.Parse(chuoi[0]), month: int.Parse(chuoi[1]), day: int.Parse(chuoi[2]));

                        var DS = db.PrizeDetails.Where(x => x.LoctionPrizeId == lottezyId).ToList();
                        //lay ra ngay hop ly
                        detail = DS.Where(x => x.DatePrize == dateTime).FirstOrDefault();
                        //lay ra giai ung voi ngay do
                        if (detail != null)
                        {
                            kq = db.Prizes.SingleOrDefault(x => x.ID == detail.PrizeId);
                            if (kq != null)
                            {
                                viewModelPrize = new ViewModelPrize(kq);
                                viewModelPrize.date = date;
                                viewModelPrize.LottezyId = detail.LoctionPrizeId.ToString();
                                viewModelPrize.LottezyName = db.LocationPrizes.SingleOrDefault(x => x.ID == detail.LoctionPrizeId).Name;
                            }



                        }


                    }



                }
                catch
                {
                    Response res = new Response();
                    res.code = 1;
                    return Ok(res);
                }





            }
            if (kq == null)
                return Ok(new Response
                {
                    code = 1
                });
            else
            {
                return Ok(new Response
                {
                    code = 0,
                    data = viewModelPrize
                }
                    );
            }

        }





        /// <summary>
        /// updae lottezy
        /// </summary>
        /// <param name="lottezyId"></param>
        /// <param name="viewModelUpdateLottezy"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("lottezy/{lottezyId}")]
        public IHttpActionResult Update_Lottezy(int lottezyId, [FromBody]ViewModelPrize viewModelPrize)
        {
            try
            {
                // MaiPH
                // check login
                String token = Request.Headers.Authorization.Scheme;
                tokenService.verifyToken(token);


                using (var db = new XSKTDBDataContext())
                {
                    db.DeferredLoadingEnabled = false;
                    PrizeDetail prizeDetail = db.PrizeDetails.Where(x => x.LoctionPrizeId == lottezyId).Where(x => x.DatePrize == tachNgay(viewModelPrize.date)).FirstOrDefault();
                    if (prizeDetail != null)
                    {
                        Prize prize = db.Prizes.Single(x => x.ID == prizeDetail.PrizeId);
                        prize.FirstPrize = ConvertListToString(viewModelPrize.FirstPrize);
                        prize.SecondPrize = ConvertListToString(viewModelPrize.SecondPrize);
                        prize.ThirdPrize = ConvertListToString(viewModelPrize.ThirdPrize);
                        prize.FourthPrize = ConvertListToString(viewModelPrize.FourthPrize);
                        prize.FifthPrize = ConvertListToString(viewModelPrize.FirstPrize);
                        prize.SixthPrize = ConvertListToString(viewModelPrize.FirstPrize);
                        prize.SeventhPrize = ConvertListToString(viewModelPrize.FirstPrize);
                        prize.SpecialPrize = ConvertListToString(viewModelPrize.FirstPrize);
                        db.SubmitChanges();
                        return Ok(new Response
                        {
                            code = 0
                        });
                    }
                }
            }
            catch
            {
                return Ok(new Response
                {
                    code = 1
                });
            }
            return Ok(new Response
            {
                code = 1
            });
        }

        /// <summary>
        /// Them moi xo so
        /// </summary>
        /// <param name="lottezyId"></param>
        /// <param name="prize"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("lottezy/{lottezyId}")]
        public IHttpActionResult Add_Lottezy(int lottezyId, [FromBody] ViewModelPrize viewModelPrize)
        {
            try
            {
                // MaiPH
                // check login
                String token = Request.Headers.Authorization.Scheme;
                tokenService.verifyToken(token);
                //
                using (var db = new XSKTDBDataContext())
                {
                    db.DeferredLoadingEnabled = false;
                    DateTime date = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour: 0, minute: 00, second: 0);
                    PrizeDetail prizeDetail = db.PrizeDetails.Where(x => x.LoctionPrizeId == lottezyId).Where(x => x.DatePrize == date).FirstOrDefault();
                    if (prizeDetail == null)
                    {
                        Prize prize = new Prize
                        {
                            FirstPrize = ConvertListToString(viewModelPrize.FirstPrize),
                            SecondPrize = ConvertListToString(viewModelPrize.SecondPrize),
                            ThirdPrize = ConvertListToString(viewModelPrize.ThirdPrize),
                            FourthPrize = ConvertListToString(viewModelPrize.FourthPrize),
                            FifthPrize = ConvertListToString(viewModelPrize.FifthPrize),
                            SixthPrize = ConvertListToString(viewModelPrize.SixthPrize),
                            SeventhPrize = ConvertListToString(viewModelPrize.SeventhPrize),
                            SpecialPrize = ConvertListToString(viewModelPrize.SpecialPrize)
                        };
                    db.Prizes.InsertOnSubmit(prize);
                    db.SubmitChanges();
                    PrizeDetail detail = new PrizeDetail
                    {
                        LoctionPrizeId = lottezyId,
                        PrizeId = prize.ID,
                        DatePrize = date
                    };
                    db.PrizeDetails.InsertOnSubmit(detail);

                    db.SubmitChanges();
                    return Ok(new Response
                    {
                        code = 0
                    });
                }
            }
            }
            catch
            {
                return Ok(new Response
                {
                    code = 1
                });
            }
            return Ok(new Response
            {
                code = 1
            });
        }


        [HttpGet]
[Route("lottezy/{lottezyId}/statistical")]
public IHttpActionResult Statiscal(int lottezyId, [FromUri] string from, [FromUri] string to)
{
    List<ViewModelStatiscal> list = new List<ViewModelStatiscal>();
    DateTime timeFrom = tachNgay(from);
    DateTime timeTo = tachNgay(to);
    Dictionary<int, int> dictionary = new Dictionary<int, int>();
    using (var db = new XSKTDBDataContext())
    {
        db.DeferredLoadingEnabled = false;
        for (DateTime tam = timeFrom; tam <= timeTo; tam = tam.AddDays(1))
        {
            var detail = db.PrizeDetails.Where(x => x.LoctionPrizeId == lottezyId).Where(x => x.DatePrize == tam).FirstOrDefault();
            if (detail != null)
            {
                //lay ra prize cua detail
                Prize prize = db.Prizes.Single(x => x.ID == detail.PrizeId);
                if (prize != null)
                {
                    ViewModelPrize viewModelPrize = new ViewModelPrize(prize);
                    //danh sach cua 2 so cuoi
                    var listFirst = viewModelPrize.First;
                    dictionary = DemSoLanXH(dictionary, convertToInt(listFirst));

                    var listSecond = viewModelPrize.Second;
                    dictionary = DemSoLanXH(dictionary, convertToInt(listSecond));

                    var listThird = viewModelPrize.Third;
                    dictionary = DemSoLanXH(dictionary, convertToInt(listThird));

                    var listFour = viewModelPrize.Fourth;
                    dictionary = DemSoLanXH(dictionary, convertToInt(listFour));

                    var listFifth = viewModelPrize.Fifth;
                    dictionary = DemSoLanXH(dictionary, convertToInt(listFifth));

                    var listSixth = viewModelPrize.Sixth;
                    dictionary = DemSoLanXH(dictionary, convertToInt(listSixth));

                    var listSeventh = viewModelPrize.Seventh;
                    dictionary = DemSoLanXH(dictionary, convertToInt(listSeventh));

                    var listSpecial = viewModelPrize.Special;
                    dictionary = DemSoLanXH(dictionary, convertToInt(listSpecial));



                }

            }


        }
    }


    foreach (var item in dictionary.Keys)
    {
        list.Add(new ViewModelStatiscal
        {
            number = item,
            fed = dictionary[item]
        });
    }
    return Ok(new Response
    {
        code = 0,
        data = list
    });



}

public Dictionary<int, int> DemSoLanXH(Dictionary<int, int> dictionary, List<int> list)
{
    foreach (var item in list)
    {
        if (dictionary.ContainsKey(item))
        {
            dictionary[item] += 1;
        }
        else
        {
            dictionary.Add(item, 1);
        }
    }
    return dictionary;
}


public DateTime tachNgay(string date)
{
    string[] chuoi = date.Split('-');
    DateTime dateTime = new DateTime(year: int.Parse(chuoi[0]), month: int.Parse(chuoi[1]), day: int.Parse(chuoi[2]));
    return dateTime;
}

public List<int> convertToInt(List<string> list)
{
    List<int> kq = new List<int>();
    foreach (var item in list)
    {
        kq.Add(int.Parse(item));
    }
    return kq;
}

//public List<int> tachSo(string chuoi)
//{
//    string[] tach = chuoi.Split('-');
//    List<int> list = new List<int>();
//    foreach (var item in tach)
//    {
//        list.Add(int.Parse(item));
//    }
//    return list;
//}

public string ConvertListToString(List<string> list)
{
    return string.Join("-", list);
}

    }
}
