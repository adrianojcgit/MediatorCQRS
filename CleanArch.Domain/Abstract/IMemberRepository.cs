using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstract
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMembers();
        Task<Member> GetMemberById(int memberId);
        Task<Member> AddMember(Member member);
        void UpdateMember(Member member);
        Task DeleteMember(int memberId);
    }
}
