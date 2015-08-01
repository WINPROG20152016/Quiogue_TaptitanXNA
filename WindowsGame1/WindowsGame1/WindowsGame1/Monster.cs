using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class Monster
    {
        #region Properties
        Vector2 PlayerPosition;
        
        ContentManager content;
        Level level;

        Texture2D idleSprite;
        Texture2D hitSprite;
        Texture2D HundredHP;
        Texture2D NinetyHP;
        Texture2D EightyHP;
        Texture2D SeventyHP;
        Texture2D SixtyHP;
        Texture2D FiftyHP;
        Texture2D FourtyHP;
        Texture2D ThirtyHP;
        Texture2D TwentyHP;
        Texture2D TenHP;
        Texture2D ZeroHP;
        Texture2D curHpTex;

        Animation idleAnimation;
        Animation HitAnimation;

        AnimationPlayer spritePlayer;

        int stateChange = 0;//0 is for idle , 1 is for attack for monster
        public float CurHp = 0;
        public float ToHp = 0;
        int monsCount = 0;
        float PerHp = 100;
        float temp = 10;
        bool isBoss = false;
        bool isNormal = true;
        #endregion

        public Monster(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
            setHp(1);

        }


        public void LoadContent()
        {
            idleSprite = content.Load<Texture2D>("Monster/MonsterO1");
            hitSprite = content.Load<Texture2D>("Monster/MonsterO1Hit");

            
            #region HpBar
            HundredHP = content.Load<Texture2D>("HP/100");
            NinetyHP = content.Load<Texture2D>("HP/90");
            EightyHP = content.Load<Texture2D>("HP/80");
            SeventyHP = content.Load<Texture2D>("HP/70");
            SixtyHP = content.Load<Texture2D>("HP/60");
            FiftyHP = content.Load<Texture2D>("HP/50");
            FourtyHP = content.Load<Texture2D>("HP/40");
            ThirtyHP = content.Load<Texture2D>("HP/30");
            TwentyHP = content.Load<Texture2D>("HP/20");
            TenHP = content.Load<Texture2D>("HP/10");
            ZeroHP = content.Load<Texture2D>("HP/0");
            #endregion

            curHpTex = HundredHP;
            idleAnimation = new Animation(idleSprite, 0.2f, true, 6);
            HitAnimation = new Animation(hitSprite, 0.2f, true, 3);

            int positionX = 100;
            int positionY = 150;
            PlayerPosition = new Vector2(positionX, positionY);

            if (stateChange == 0)
            {
                spritePlayer.PlayAnimation(idleAnimation);
            }
            else if (stateChange == 1)
            {
                spritePlayer.PlayAnimation(HitAnimation);
            }
            

        }
        public void Update(GameTime gameTime)
        {
            

            if (CurHp <= 0)
            {
                if (level.round >= 10)
                {
                    callBoss(level.StageNumber);
                    level.StageNumber += 1;
                    level.round = 1;
                }
                if(isBoss == true)
                {
                    EnemyDie();
                    LoadContent();
                    setHp(2);
                    isBoss = false;
                    isNormal = true;
                }
                else
                {
                    EnemyDie();
                    LoadContent();
                    setHp(1);
                }
                

            }

            
        }

        private void callBoss(int stageNum)
        {
            isBoss = true;
            isNormal = false;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            

            spritePlayer.Draw(gameTime, spriteBatch, PlayerPosition, SpriteEffects.None);
            spriteBatch.Draw(curHpTex, new Vector2(100, 125), Color.White);
           
        }
        public void getHit(GameTime gameTime)
        {
            

            if (stateChange == 0)
            {
                stateChange = 1;
                LoadContent();


            }
            else if (stateChange == 1)
            {
                stateChange = 0;
                LoadContent();
            }

            if (CurHp <= 0)
            {
                temp = CurHp;
                temp += 1;
            }
            else
            {
                temp = CurHp;
            }
            PerHp = (temp / ToHp) * 100;
            if (PerHp > 90 && PerHp <= 100)
            {
                curHpTex = HundredHP;
            }
            else if (PerHp > 80 && PerHp <= 90)
            {
                curHpTex = NinetyHP;
            }
            else if (PerHp > 70 && PerHp <= 80)
            {
                curHpTex = EightyHP;
            }
            else if (PerHp > 60 && PerHp <= 70)
            {
                curHpTex = SeventyHP;
            }
            else if (PerHp > 50 && PerHp <= 60)
            {
                curHpTex = SixtyHP;
            }
            else if (PerHp > 40 && PerHp <= 50)
            {
                curHpTex = FiftyHP;
            }
            else if (PerHp > 30 && PerHp <= 40)
            {
                curHpTex = FourtyHP;
            }
            else if (PerHp > 20 && PerHp <= 30)
            {
                curHpTex = ThirtyHP;
            }
            else if (PerHp > 10 && PerHp <= 20)
            {
                curHpTex = TwentyHP;
            }
            else if (PerHp > 0 && PerHp <= 10)
            {
                curHpTex = TenHP;
            }
            else if (PerHp <= 0)
            {
                curHpTex = ZeroHP;
            }
        }
        private void setHp(int isBs)
        {
            if(isBs == 2)
            {
                ToHp = 100 * (level.StageNumber - 1);
                CurHp = ToHp;
            }
            else
            {
                ToHp = 10 * level.StageNumber;
                CurHp = ToHp;
            }
            
            

        }
        public void takeDamage(int damageTaken)
        {
            CurHp -= damageTaken;
        }
        void EnemyDie()
        {
            level.score += 100;
            if (monsCount >= 10)
            {
                level.StageNumber += 1;
            }
            else
            {
                level.round += 1;
            }
            spawnMoney();
        }
        void spawnMoney()
        {
            if(isNormal == true)
            {
                level.money += (level.round + (level.score / (level.StageNumber * 100) + (level.money / 10000)) + (level.StageNumber * 3));
            }
            else
            {
                level.money += ((level.round + (level.score / (level.StageNumber * 100) + (level.money / 10000)) + (level.StageNumber * 3))*10);
            }
            

        }

    }
}
