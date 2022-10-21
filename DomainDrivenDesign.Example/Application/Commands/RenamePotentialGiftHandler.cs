using DomainDrivenDesign.Cqrs;
using DomainDrivenDesign.Example.Domain.Commands;
using DomainDrivenDesign.Example.Domain.Persistence;
using DomainDrivenDesign.Example.Domain.Types;

namespace DomainDrivenDesign.Example.Application.Commands;

public class RenamePotentialGiftHandler : ICommandHandler<RenamePotentialGift>
{
    private readonly IFriendRepository FriendRepository;

    public RenamePotentialGiftHandler(IFriendRepository friendRepository)
    {
        FriendRepository = friendRepository;
    }

    public async Task Handle(RenamePotentialGift command)
    {
        var friend = await FriendRepository.FindById(new FriendId(command.FriendId));

        if (friend is null)
            throw new InvalidOperationException($"Friend {command.FriendId} not found.");

        var gift = friend.PotentialGifts.SingleOrDefault(_ => _.Id.Value == command.PotentialGiftId);
        
        if (gift is null)
            throw new InvalidOperationException($"Gift {command.PotentialGiftId} not found for friend {command.FriendId}.");
        
        gift.RenameTo(new GiftName(command.NewName));
        await FriendRepository.Persist(friend);
    }
}