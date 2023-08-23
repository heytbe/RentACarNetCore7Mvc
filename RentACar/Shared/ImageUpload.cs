using RentACar.Models.Dto;

namespace RentACar.Shared
{
    public static class ImageUpload
    {
        public static async Task<ImageUploadDto> Image(IFormFile formFile)
        {
            var root = Envorinment.webHost.WebRootPath;
            var extensions = Path.GetExtension(formFile.FileName);
            var newFileName = Guid.NewGuid().ToString() + extensions;
            var combine = Path.Combine(root+"/image/", newFileName);

            using(var file = new FileStream(combine,FileMode.Create))
            {
                await formFile.CopyToAsync(file);
                await file.DisposeAsync();
            }

            return new ImageUploadDto
            {
                ImageName = formFile.FileName,
                ImagePath = "/image/"+newFileName,
                ImageSize = formFile.Length
            };
        }
    }
}
