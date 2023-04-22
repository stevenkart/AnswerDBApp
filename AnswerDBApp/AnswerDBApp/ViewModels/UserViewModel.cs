using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AnswerDBApp.Models;

namespace AnswerDBApp.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

        //VM
        public User MyUser { get; set; }
        public UserDTO MyUserDTO { get; set; }

        public UserViewModel()
        {
            MyUser = new User();
            MyUserDTO = new UserDTO();
        }

        //FUNCIONALIDAD principal del VM

        public async Task<UserDTO> GetUserByID(int pId)
        {

            if (IsBusy)
            {
                return null;
            }
            else
            {
                IsBusy = true;
            }

            try
            {
                UserDTO user = new UserDTO();

                user = await MyUserDTO.GetUser(pId);

                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }
            }
            catch (Exception)
            {
                return null;

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }










    }
}
