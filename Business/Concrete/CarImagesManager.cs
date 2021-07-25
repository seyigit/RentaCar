using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccss.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImageService
    {
        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;

        public CarImagesManager(ICarImagesDal carImagesDal,IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(CarImages carImages,IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageCarCount(carImages.CarId));
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            var imageResult = _fileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImages.ImagePath = imageResult.Message;
            carImages.date = DateTime.Now;
            _carImagesDal.Add(carImages);
            return new SuccesResult(Messages.AddToCarImageSuccessMessage);
        }

        public IResult Delete(CarImages carImages)
        {
            var imageDelete = _carImagesDal.Get(c => c.Id == carImages.Id);
            if (imageDelete == null)
            {
                return new ErrorResult("İmage not found");
            }
            _carImagesDal.Delete(carImages);

            return new SuccesResult(Messages.DeleteToCarImageSuccessMessage);
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(), Messages.GetAllFilterSuccessMessage);
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(c=>c.Id == id),Messages.GetByIdFilterSuccessMessage);
        }

        public IDataResult<List<CarImages>>GetByImageByCarId(int id)
        {
            var result = BusinessRules.Run(ShowDefaultImage(id));
            if (result == null)
            {
                return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(c => c.CarId == id));
               
            }
            return new ErrorDataResult<List<CarImages>>("Hata");
        }

        public IResult Update(CarImages carImages, IFormFile file)
        {
            var imageDelete = _carImagesDal.Get(c => c.Id == carImages.Id);
            if (imageDelete==null)
            {
                return new ErrorResult("Not Found");
            }
            var updatedFile = _fileHelper.Update(file, imageDelete.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImages.ImagePath = updatedFile.Message;
            _carImagesDal.Update(carImages);

            return new SuccesResult(Messages.UpdateToCarImageSuccessMessage);
        }

        private IResult CheckImageCarCount(int carId)
        {
            var imagesCount = _carImagesDal.GetAll(p => p.CarId == carId).Count;
            if (imagesCount>5)
            {
                return new ErrorResult("1 Arabanın 5ten fazla resmi olamaz.");
            }
            return new SuccesResult();
        }
        private IResult ShowDefaultImage(int carId)
        {
            

            try
            {
                string path = @"\Images\default.png";
                var result = _carImagesDal.GetAll(c=>c.CarId==carId).Any();
                if (result)
                {
                    List<CarImages> carImages = new List<CarImages>();
                    carImages.Add(new CarImages { CarId = carId, date = DateTime.Now, ImagePath = path });
                    return new SuccessDataResult<List<CarImages>>(carImages);
                }
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<CarImages>>("Hata");
            }
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(c => c.CarId == carId).ToList());
        }
    }
}
