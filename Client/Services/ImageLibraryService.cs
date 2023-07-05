using BlazorAppWSAM.Shared.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace BlazorAppWSAM.Client.Services
{
    public class ImageLibraryService : IImageLibraryService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public ImageLibraryService(HttpClient httpClient, NavigationManager navigationManager)
        {
            this._httpClient = httpClient;
            this._navigationManager = navigationManager;
            //this._httpClient.BaseAddress = new Uri("https://blazorappwsamserver20230704093213.azurewebsites.net");
            this._httpClient.BaseAddress = new Uri(_navigationManager.BaseUri);
        }

        public async Task<ImageLibrary> AddImage(ImageLibrary imageLibrary, MultipartFormDataContent multipartFormDataContent)
        {
            try
            {
                var response1 = await _httpClient.PostAsync("api/filesave/postfile", multipartFormDataContent);
                imageLibrary.UniqueTitle = response1.Headers.Location.ToString();
                var httpResponse = await response1.Content.ReadAsStringAsync();
                JsonDocument jsonDocument = JsonDocument.Parse(httpResponse);
                JsonElement firstElement = jsonDocument.RootElement[0];
                string storedFileName = firstElement.GetProperty("storedFileName").GetString();
                string fileName = firstElement.GetProperty("fileName").GetString();

                imageLibrary.UniqueTitle = storedFileName;
                imageLibrary.Path = fileName;

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
