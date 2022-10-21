using DomainDrivenDesign.Cqrs;
using DomainDrivenDesign.Example.Domain.Commands;
using DomainDrivenDesign.Example.Domain.Persistence;
using DomainDrivenDesign.Example.Domain.Types;

namespace DomainDrivenDesign.Example.Application.Commands;

public sealed class RenameFriendHandler : ICommandHandler<RenameFriend>
{
    private readonly IFriendRepository FriendRepository;

    public RenameFriendHandler(IFriendRepository friendRepository)
    {
        FriendRepository = friendRepository;
    }

    public async Task Handle(RenameFriend command)
    {
        var friend = await FriendRepository.FindById(new FriendId(command.FriendId));

        if (friend is null)
            throw new InvalidOperationException($"Friend {command.FriendId} not found.");

        friend.RenameTo(new FriendName(command.NewName));
        await FriendRepository.Persist(friend);
    }
}