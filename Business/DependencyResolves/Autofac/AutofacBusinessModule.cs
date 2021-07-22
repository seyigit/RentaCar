﻿using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccss.Abstract;
using DataAccss.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Car Autofac Service
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            //Brand Autofac Service
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            //Color Autofac Service

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
        }
    }
}