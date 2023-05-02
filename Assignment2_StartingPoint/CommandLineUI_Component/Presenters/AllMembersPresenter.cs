using DTOs;
using UseCase;

namespace CommandLineUI.Presenters
{
    class AllMembersPresenter : AbstractPresenter
    {

        public override IViewData ViewData
        {
            get
            {
                List<MemberDTO> members = ((MemberDTO_List)DataToPresent).List;
                List<string> lines = new List<string>(members.Count + 2);
            

                members.ForEach(m => lines.Add(DisplayMember(m)));

                return new CommandLineViewData(lines);
            }
        }

        private string DisplayMember(MemberDTO m)
        {
            return string.Join(",",
                m.ID.ToString().PadRight(4),
                m.Name);
        }
    }
}
