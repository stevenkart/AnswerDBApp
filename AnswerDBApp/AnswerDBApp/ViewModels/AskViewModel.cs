using AnswerDBApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnswerDBApp.ViewModels
{
    public class AskViewModel : BaseViewModel
    {

        //VM
        public Ask MyAsk { get; set; }

        public AskViewModel()
        {
            MyAsk = new Ask();
      
        }

        //FUNCIONALIDAD principal del VM

        public async Task<bool> AddNewAsk(string Ask, string AskDetail)
        {

            if (IsBusy)
            {
                return false;
            }
            else
            {
                IsBusy = true;
            }

            try
            {
                MyAsk.AskId = 0;
                MyAsk.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()); //Fecha Quemada 
                MyAsk.Ask1 = Ask;
                MyAsk.UserId = GlobalObjects.LocalUser.UserId;
                MyAsk.AskStatusId = 1; //Se paso quemado porque siempre al hacer la pregunta va nacer pendiente de que se responda
                MyAsk.IsStrike = false;
                MyAsk.ImageUrl = "TestSoftware.png";
                MyAsk.AskDetail = AskDetail;


                bool R = await MyAsk.AddAsk();

                return R;

            }
            catch (Exception)
            {
                return false;

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<List<Ask>> GetAsksByFilter(int state)
        {
            try
            {
                List<Ask> asksList = new List<Ask>();

                asksList = await MyAsk.GetByFilterAskState(state);

                if (asksList == null)
                {
                    return null;
                }
                else
                {
                    return asksList;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
