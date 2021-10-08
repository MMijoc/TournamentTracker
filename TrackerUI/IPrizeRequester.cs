using TrackerLibrary.Models;

namespace TrackerUIFrame
{
	public interface IPrizeRequester
	{
		void PrizeComplete(PrizeModel model);
	}
}
