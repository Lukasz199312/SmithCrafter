using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Views
{
    public class CopyValues
    {
        public void CopyScale(Transform Target, Transform Source, Transform Parent)
        {
            Target.parent = null;

            Vector3 Scale = Source.localScale;
            Target.localScale = new Vector3(Scale.x, Scale.y, Scale.x);

            Target.parent = Parent;

        }

        public void CopySpriteRender(SpriteRenderer Target, SpriteRenderer Source)
        {
            Target.sprite = Source.sprite;
        }

        public void CopyBoxCollider2D(BoxCollider2D Target, BoxCollider2D Source)
        {
            Target.size = Source.size;
        }
    }

}