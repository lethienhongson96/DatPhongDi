﻿namespace DatPhongDi.Domain.Response.Customer
{
    public class CustomerView : ResResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
    }
}
