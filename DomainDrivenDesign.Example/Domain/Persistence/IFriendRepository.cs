using DomainDrivenDesign.Example.Domain.Types;

namespace DomainDrivenDesign.Example.Domain.Persistence;

public interface IFriendRepository
{
    Task<Friend?> FindById(FriendId id);
    Task Persist(Friend friend);
}