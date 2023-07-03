using BlazorAppWSAM.Shared.Models;
using System.Net.Http.Json;

namespace BlazorAppWSAM.Client.Services
{
    public class ImageLibraryService : IImageLibraryService
    {
        private readonly HttpClient _httpClient;
        public ImageLibraryService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._httpClient.BaseAddress = new Uri("https://blazorappwsamclient20230704041151.azurewebsites.net");
        }

        public async Task<ImageLibrary> AddImage(ImageLibrary imageLibrary)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<ImageLibrary>("api/imagelibrary/CreateImage", imageLibrary);
                return await response.Content.ReadFromJsonAsync<ImageLibrary>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteImage(ImageLibrary imageLibrary)
        {
            var response = await _httpClient.DeleteAsync($"api/imagelibrary/DeleteImageById?id={imageLibrary.Id}");
        }

        public Task<IEnumerable<ImageLibrary>> GetImageByCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<ImageLibrary> GetImageById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ImageLibrary>> GetImageListAll()
        {
            IEnumerable<ImageLibrary> imageLibrary;
            imageLibrary = await _httpClient.GetFromJsonAsync<IEnumerable<ImageLibrary>>("api/imagelibrary/GetAllImageList");
            return imageLibrary;
        }

        public Task<ImageLibrary> SearchImage(string title)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateImage(ImageLibrary imageLibrary)
        {
            var response = await _httpClient.PutAsJsonAsync<ImageLibrary>($"api/imagelibrary/UpdateImageById?id={imageLibrary.Id}", imageLibrary);
        }
    }
}
