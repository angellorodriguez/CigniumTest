using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cignium.Core.Entities;

namespace Cignium.Infrastructure.Data
{
    public class CatalogTablePremium
    {

        public List<TablePremium> FindByParameters(string sta, string month, int age) { 
            //This function make all the logic to validate all casuistics, even when you register the character * in the source
        List<TablePremium> list = new List<TablePremium>();
            //here we call the source, we are not calling a database so it is generated in a function
        list = CreateMockData();
         //Filters for each level, for age, month and state
        List<TablePremium> listFILTERED1 = new List<TablePremium>();
        List<TablePremium> listFILTERED2 = new List<TablePremium>();
        List<TablePremium> listFILTERED3 = new List<TablePremium>();
        listFILTERED1 = list.Where(filter => filter.AgeMin <= age && filter.AgeMax >= age).ToList();
            if (listFILTERED1.Count > 0)
            {
                listFILTERED2 = listFILTERED1.Where(filter => filter.MonthOfBirth == month).ToList();

                if (listFILTERED2.Count > 0)
                {
                    listFILTERED3 = listFILTERED2.Where(filter => filter.State == sta).ToList();
                    if (listFILTERED3.Count > 0)
                    {
                        return listFILTERED3;
                    }
                    else
                    {
                        listFILTERED3 = listFILTERED2.Where(filter => filter.State == "*").ToList();
                        if (listFILTERED3.Count > 0)
                        {
                            return listFILTERED3;
                        }
                        else
                        {
                            listFILTERED3 = listFILTERED1.Where(filter => filter.MonthOfBirth == "*" && filter.State ==sta).ToList();
                            if (listFILTERED3.Count > 0)
                            {
                                return listFILTERED3;
                            }
                            else
                            {
                                listFILTERED3 = listFILTERED1.Where(filter => filter.MonthOfBirth == "*" && filter.State == "*").ToList();
                                return listFILTERED3;
                            }
                        }
                            
                    }
                }
                else
                {
                    listFILTERED2 = listFILTERED1.Where(filter => filter.MonthOfBirth == "*").ToList();
                    if (listFILTERED2.Count > 0) 
                    {
                        listFILTERED3 = listFILTERED2.Where(filter => filter.State == sta).ToList();
                        if (listFILTERED3.Count > 0)
                        {
                            return listFILTERED3;
                            
                        }
                        else
                        {
                            listFILTERED3 = listFILTERED2.Where(filter => filter.State == "*").ToList();
                            return listFILTERED3;
                        }
                    }
                    else
                    {
                        return listFILTERED2;
                    }
                }
            }
            else
            {
                return listFILTERED1;
            }

        }
        private List<TablePremium> CreateMockData()
        {
            //You can ADD here new values to retrieve different Premiums. For example new STATE "NC", between ages 18 and 20, and month of bith February (2)
            List<TablePremium> ret = new List<TablePremium>();
            ret.Add(new TablePremium()
            {
                State = "NY",
                MonthOfBirth = "8",
                AgeMin = 18,
                AgeMax = 45,
                Premium = 150.00
            });

            ret.Add(new TablePremium()
            {
                State = "NY",
                MonthOfBirth = "1",
                AgeMin = 46,
                AgeMax = 65,
                Premium = 200.50
            });

            ret.Add(new TablePremium()
            {
                State = "NY",
                MonthOfBirth = "*",
                AgeMin = 18,
                AgeMax = 65,
                Premium = 120.99
            });

            ret.Add(new TablePremium()
            {
                State = "AL",
                MonthOfBirth = "11",
                AgeMin = 18,
                AgeMax = 65,
                Premium = 85.50
            });

            ret.Add(new TablePremium()
            {
                State = "AL",
                MonthOfBirth = "*",
                AgeMin = 18,
                AgeMax = 65,
                Premium = 100.00
            });
            ret.Add(new TablePremium()
            {
                State = "AK",
                MonthOfBirth = "12",
                AgeMin = 65,
                AgeMax = 100,
                Premium = 175.20
            });

            ret.Add(new TablePremium()
            {
                State = "AK",
                MonthOfBirth = "12",
                AgeMin = 18,
                AgeMax = 64,
                Premium = 125.16
            });

            ret.Add(new TablePremium()
            {
                State = "AK",
                MonthOfBirth = "*",
                AgeMin = 18,
                AgeMax = 65,
                Premium = 100.80
            });

            ret.Add(new TablePremium()
            {
                State = "*",
                MonthOfBirth = "*",
                AgeMin = 18,
                AgeMax = 65,
                Premium = 90.00
            });
            return ret;
        }
    }
}
