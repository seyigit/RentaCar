﻿using Core.DataAccess.EntityFramework;
using DataAccss.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccss.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color,RentacarContext>,IColorDal
    {
       
    }
}
