using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    internal class SinhVien
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string id { get; set; }

        public SinhVien() { }

        public SinhVien(string firstName, string lastName, string id)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
        }
    }
}
