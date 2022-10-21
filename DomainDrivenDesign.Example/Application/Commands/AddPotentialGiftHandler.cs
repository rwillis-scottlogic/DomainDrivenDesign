using DomainDrivenDesign.Cqrs;
using DomainDrivenDesign.Example.Domain.Commands;
using DomainDrivenDesign.Example.Domain.Persistence;
using DomainDrivenDesign.Example.Domain.Types;

namespace DomainDrivenDesign.Example.Application.Commands;

public class AddPotentialGiftHandler : ICommandHandler<AddPotentialGift>
{
    private readonly IFriendRepository FriendRepository;

    public AddPotentialGiftHandler(IFriendRepository friendRepository)
    {
        FriendRepository = friendRepository;
    }

    public async Task Handle(AddPotentialGift command)
    {
        var friend = await FriendRepository.FindById(new FriendId(command.FriendId));

        if (friend is null)
            throw new InvalidOperationException($"Friend {command.FriendId} not found.");

        var gift = Gift.New(new GiftName(command.Name));
        friend.AddPotentialGift(gift);
        await FriendRepository.Persist(friend);
    }
}