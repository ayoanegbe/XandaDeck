﻿using XandaDeck.Data.Models;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;

namespace XandaDeck.Core.Services
{
    public class CustomIDataProtection
    {
        private readonly IDataProtector protector;
        public CustomIDataProtection(IDataProtectionProvider dataProtectionProvider, UniqueCode uniqueCode)
        {
            protector = dataProtectionProvider.CreateProtector(uniqueCode.IdRouteValue);
        }

        
        public string Decode(string data)
        {
            return protector.Unprotect(data);
        }
        public string Encode(string data)
        {
            return protector.Protect(data);
        }
    }
}
