using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XSKTDB;

namespace API.Models
{
    /// <summary>
    /// lop co du lieu json cac giai la list string
    /// </summary>
    public class ViewModelPrize
    {
        public string LottezyId { get; set; }
        public string LottezyName { get; set; }
        public string date { get; set; }
        public List<string> FirstPrize { get; set; }
        public List<string> SecondPrize { get; set; }
        public List<string> ThirdPrize { get; set; }
        public List<string> FourthPrize { get; set; }
        public List<string> FifthPrize { get; set; }
        public List<string> SixthPrize { get; set; }
        public List<string> SeventhPrize { get; set; }
        public List<string> SpecialPrize { get; set; }

        public ViewModelPrize()
        {

        }

        public ViewModelPrize(Prize prize)
        {
            FirstPrize = convertToList(prize.FirstPrize);
            SecondPrize = convertToList(prize.SecondPrize);
            ThirdPrize = convertToList(prize.ThirdPrize);
            FourthPrize = convertToList(prize.FourthPrize);
            FifthPrize = convertToList(prize.FifthPrize);
            SixthPrize = convertToList(prize.SixthPrize);
            SeventhPrize = convertToList(prize.SeventhPrize);
            SpecialPrize = convertToList(prize.SpecialPrize);

        }

        public List<string> First
        {
            get
            {
                return tachCuoi(FirstPrize);
            }
        }

        public List<string> Second
        {
            get
            {
                return tachCuoi(SecondPrize);
            }
        }

        public List<string> Third
        {
            get
            {
                return tachCuoi(ThirdPrize);
            }
        }

        public List<string> Fourth
        {
            get
            {
                return tachCuoi(FourthPrize);
            }
        }

        public List<string> Fifth
        {
            get
            {
                return tachCuoi(FifthPrize);
            }
        }
        public List<string> Sixth
        {
            get
            {
                return tachCuoi(SixthPrize);
            }
        }

        public List<string> Seventh
        {
            get
            {
                return tachCuoi(SeventhPrize);
            }
        }

        public List<string> Special
        {
            get
            {
                return tachCuoi(SpecialPrize);
            }
        }

        public List<string> convertToList(string chuoi)
        {
            string[] tach = chuoi.Split('-');
            return tach.ToList();
        }

        public List<string> tachCuoi(List<string> chuoi)
        {

            List<string> kq = new List<string>();
            if (chuoi.Count > 0)
            {
                foreach (var item in chuoi)
                {
                    kq.Add(item.Substring(item.Length - 2, 2));
                }
            }
           
            return kq;
        }
    }
    
}