﻿using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEmployeesService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges);

    }
}
