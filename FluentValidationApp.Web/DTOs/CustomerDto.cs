﻿using System;

namespace FluentValidationApp.Web.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Isım { get; set; }
        public string Eposta { get; set; }
        public int Yas { get; set; }
        public string FullName { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime CreditCardValidDate { get; set; }
    }
}