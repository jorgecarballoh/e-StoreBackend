using MediatR;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Aplication.Features.Items.Queries.GetItemById;
using Play.Catalog.Aplication.Features.Items.Queries.GetItemsList;
using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
     
        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> Get()
        {
            var listOfItems = await _mediator.Send(new GetItemsListQuery());
            return Ok(listOfItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetById(Guid id)
        {
            var item = await _mediator.Send(new GetItemByIdQuery(id));
            return Ok(item);
        }

        //[HttpPost]
        //public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        //{
        //    var item = new ItemDto(Guid.NewGuid(),
        //                        createItemDto.Name,
        //                        createItemDto.Description,
        //                        createItemDto.Price,
        //                        DateTimeOffset.UtcNow);

        //    items.Add(item);

        //    return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        //}

        //[HttpPut("{id}")]
        //public ActionResult Put(Guid id, UpdateItemDto updateItemDto)
        //{
        //    var existingItem = items.Where(item => item.Id == id).SingleOrDefault();

        //    if (existingItem is null)
        //    {
        //        ItemDto item = new ItemDto(id,
        //                                   updateItemDto.Name,
        //                                   updateItemDto.Description,
        //                                   updateItemDto.Price,
        //                                   DateTimeOffset.UtcNow);

        //        items.Add(item);
        //        return CreatedAtAction(nameof(GetById), new { id }, item);
        //    }

        //    var updatedItem = existingItem with
        //    {
        //        Name = updateItemDto.Name,
        //        Description = updateItemDto.Description,
        //        Price = updateItemDto.Price
        //    };

        //    var index = items.FindIndex(item => item.Id == id);
        //    items[index] = updatedItem;

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete(Guid id)
        //{
        //    var index = items.FindIndex(item => item.Id == id);

        //    if (index < 0) return NotFound();

        //    items.RemoveAt(index);

        //    return NoContent();
        //}
    }
}