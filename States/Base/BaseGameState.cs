using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameMastery.Objects.Base;

namespace MonoGameMastery.States.Base
{
    public abstract class BaseGameState
    {
        private readonly List<BaseGameObject> _gameObjects = new List<BaseGameObject>();

        public abstract void LoadContent(ContentManager contentManager);
        public abstract void UnloadContent(ContentManager contentManager);
        public abstract void HandInput();
        public event EventHandler<BaseGameState> OnStateSwitched;
        protected void SwitchGameState(BaseGameState state)
        {
            OnStateSwitched?.Invoke(this, state);
        }

        public void Render(SpriteBatch spriteBatch)
        {
            foreach(BaseGameObject gameObj in _gameObjects.OrderBy(obj => obj.zIndex))
            {
                gameObj.Render(spriteBatch);
            }
        }
    }
}