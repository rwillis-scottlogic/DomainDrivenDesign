using DomainDrivenDesign.Example.Domain.Persistence;
using DomainDrivenDesign.Example.Domain.Types;

namespace DomainDrivenDesign.Example.Application;

public sealed class FriendRepository : IFriendRepository
{
    public Task<Friend?> FindById(FriendId id)
    {
        /*
         *
         * Retrieve the complete Friend object with the given ID from persistence.
         *
         * e.g. SQL
         * SELECT * FROM [Friend] WHERE [Id] = @id
         * SELECT * FROM [PotentialGift] WHERE [FriendId] = @id
         * 
         */
        
        throw new NotImplementedException();
    }

    public Task Persist(Friend friend)
    {
        /*
         *
         * Identify the changes in the Friend object and its constituent entities by inspecting its published events.
         * Persist those changes into the underlying storage mechanism.
         *
         * e.g. SQL
         * FriendAdded -> INSERT INTO [Friend] ...
         * GiftRenamed -> UPDATE [PotentialGift] ...
         * etc.
         * 
         */
        
        throw new NotImplementedException();
    }
}