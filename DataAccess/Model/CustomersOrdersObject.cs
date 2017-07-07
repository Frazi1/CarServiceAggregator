﻿using System;

namespace DataAccess.Model
{
    [Serializable]
    public class CustomersOrdersObject
    {
        public Customer[] Customers { get; set; }
        public Order[] Orders { get; set; }
    }
}