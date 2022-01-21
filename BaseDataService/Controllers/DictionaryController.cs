using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.InputDto.Dictionary;
using Model.OutputDto;
using DM = Model.DBModel;

namespace BaseDataService.Controllers
{
    [ApiController]
    public class DictionaryController : BaseController
    {
        [HttpGet]
        public async Task<ApiResponse<List<DM.Dictionary>>> Get(string Type)
        {
            return Success(await _Db.Dictionary.Where(w => w.Type == Type).ToListAsync());
        }
        [HttpPost]
        public async Task<ApiResponse> Add(DictionaryInput dto)
        {
            var model = _Mapper.Map<DM.Dictionary>(dto);
            _Db.Dictionary.Add(model);
            var result = await _Db.SaveChangesAsync();
            return Success(result);
        }
    }
}
