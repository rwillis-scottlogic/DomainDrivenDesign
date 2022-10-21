using DomainDrivenDesign.Cqrs;
using DomainDrivenDesign.Example.Domain.Commands;
using DomainDrivenDesign.Example.Domain.Persistence;
using DomainDrivenDesign.Example.Domain.Types;

namespace DomainDrivenDesign.Example.Application.Commands;

public sealed class AddFriendHandler : ICommandHandler<AddFriend>
{
    private readonly IFriendRepository FriendRepository;

    public AddFriendHandler(IFriendRepository friendRepository)
    {
        FriendRepository = friendRepository;
    }

    public async Task Handle(AddFriend command)
    {
        var friendName = new FriendName(command.Name);
        var friend = Friend.New(friendName);

        await FriendRepository.Persist(friend);
    }
}