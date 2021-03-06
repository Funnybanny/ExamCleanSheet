﻿using BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Converter
{
    public class Converter
    {
        string path = @"Folder/";

        public void Convert()
        {
            ServiceGateway sg = new ServiceGateway();
            sg.postMany(ReadFiles());
        }

        private string[] GetFiles()
        {
            string[] files = Directory.GetFiles(path, "*.txt");

            return files;
        }

        private List<Customer> ReadFiles()
        {
            List<Customer> lst = new List<Customer>();
            string[] files = GetFiles();
            string line;
            for (int i = 0; i < files.Length; i++)
            {
                int counter = 0;
                Customer c = new Customer();
                StreamReader file = new StreamReader(files[i]);
                while ((line = file.ReadLine()) != null)
                {
                    string l = line.Substring(11);
                    if (counter == 0)
                    {
                        c.Name = l;
                    }
                    if (counter == 1)
                    {
                        c.BirthDate = DateTime.ParseExact(l, "yyyy-mm-dd", CultureInfo.InvariantCulture);
                    }
                    if (counter == 2)
                    {
                        c.Address = l;
                    }
                    if (counter == 3)
                    {
                        c.PhoneNumber = Int32.Parse(l);
                    }
                    counter++;
                }
                lst.Add(c);
            }
            return lst;
        }
    }
}
