using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Api.Domain.Items;
using Play.Catalog.Api.Dtos;
using Play.Common;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public ItemsController(IRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAsync()
        {
            var allItems = await _itemRepository.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<ItemDto>>(allItems);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = await _itemRepository.GetAsync(id);

            if (item is null) return NotFound();

            var dto = _mapper.Map<ItemDto>(item);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto)
        {
            var item = _mapper.Map<Item>(createItemDto);
            await _itemRepository.CreateAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await _itemRepository.GetAsync(id);

            if (existingItem is  null) return NotFound();

            var itemUpdated = _mapper.Map(updateItemDto, existingItem);

            await _itemRepository.UpdateAsync(itemUpdated);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var existingItem = await _itemRepository.GetAsync(id);

            if (existingItem is null) return NotFound();

            await _itemRepository.RemoveAsync(id);
             
            return NoContent();
        }
    }
}