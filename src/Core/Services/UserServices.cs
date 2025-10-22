using Core.Entities;
using Core.Dtos;

namespace Core.Services
{
    public class UserService
    {
        private static List<User> Users = new List<User>();

        // Obtener todos los usuarios
        public List<UserDto> GetAll()
        {
            return Users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.FirstName + " " + u.LastName,
                Email = u.Email
            }).ToList();
        }

        // Obtener usuario por Id
        public UserDto? GetById(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email
            };
        }

        // Crear un nuevo usuario
        public void Create(User user)
        {
            user.Id = Users.Count > 0 ? Users.Max(u => u.Id) + 1 : 1;
            Users.Add(user);
        }

        // Actualizar un usuario
        public bool Update(int id, User updatedUser)
        {
            var existing = Users.FirstOrDefault(u => u.Id == id);
            if (existing == null) return false;

            existing.FirstName = updatedUser.FirstName;
            existing.LastName = updatedUser.LastName;
            existing.Email = updatedUser.Email;
            existing.IsActive = updatedUser.IsActive;
            existing.Phone = updatedUser.Phone;
            return true;
        }

        // Eliminar un usuario
        public bool Delete(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;

            Users.Remove(user);
            return true;
        }
    }
}
