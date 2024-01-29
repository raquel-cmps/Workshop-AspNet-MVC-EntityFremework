﻿namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() { }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Department(string name)
        {
            Name = name;
        }

        public void AddSeler(Seller seller)
        {
            Sellers.Add(seller);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            //pego todos os meus vendedores e somo as vendas daquele periodo
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}