using DomainDrivenDesign.Cqrs;
using DomainDrivenDesign.Example.Api.Request;
using DomainDrivenDesign.Example.Api.Response;
using DomainDrivenDesign.Example.Domain.Commands;
using DomainDrivenDesign.Example.Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenDesign.Example.Api;

public class FriendsController : Controller
{
    private readonly IQueryBus Queries;
    private readonly ICommandBus Commands;

    public FriendsController(IQueryBus queries, ICommandBus commands)
    {
        Queries = queries;
        Commands = commands;
    }

    [HttpGet("friends/{id:guid}")]
    public async Task<IActionResult> FindFriend([FromRoute] Guid id)
    {
        var query = new FindSpecificFriend(id);
        var result = await Queries.Dispatch<FindSpecificFriend, FriendDetail?>(query);

        if (result is null)
            return NotFound();

        return Ok(FriendDetailResponse.From(result));
    }
    
    [HttpGet("friends")]
    public async Task<IActionResult> SearchFriends([FromQuery] string nameMatch)
    {
        var query = new SearchFriends(nameMatch);
        var result = await Queries.Dispatch<SearchFriends, IEnumerable<FriendDetail>>(query);
        return Ok(result.Select(FriendDetailResponse.From));
    }

    [HttpPost("friends")]
    public async Task<IActionResult> AddFriend([FromBody] AddFriendRequest request)
    {
        var command = new AddFriend(request.Name);
        await Commands.Dispatch(command);
        return Ok();
    }

    [HttpPut("friends/{id:guid}/name")]
    public async Task<IActionResult> RenameFriend(
        [FromRoute] Guid id,
        [FromBody] RenameFriendRequest request)
    {
        var command = new RenameFriend(id, request.NewName);
        await Commands.Dispatch(command);
        return Ok();
    }

    [HttpPost("friends/{friendId:guid}/gifts")]
    public async Task<IActionResult> AddPotentialGift(
        [FromRoute] Guid friendId,
        [FromBody] AddPotentialGiftRequest request)
    {
        var command = new AddPotentialGift(friendId, request.Name);
        await Commands.Dispatch(command);
        return Ok();
    }
    
    [HttpPut("friends/{friendId:guid}/name/{giftId:int}")]
    public async Task<IActionResult> RenameFriend(
        [FromRoute] Guid friendId,
        [FromRoute] int giftId,
        [FromBody] RenamePotentialGiftRequest request)
    {
        var command = new RenamePotentialGift(friendId, giftId, request.NewName);
        await Commands.Dispatch(command);
        return Ok();
    }
}