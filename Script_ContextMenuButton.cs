using UnityEngine;
#if UNITY_EDITOR //To avoid errors during the build
using System.Reflection; //needed
using UnityEditor; //needed
#endif

public class Script_ContextMenuButton : MonoBehaviour
{
    [ContextMenu("Move Up")]
    void MoveUp()
    {
        transform.position += Vector3.up;
    }

    [ContextMenu("Move Down")]
    void MoveDown()
    {
        transform.position += Vector3.down;
    }

    [ContextMenu("Move Left")]
    void MoveLeft()
    {
        transform.position += Vector3.left;
    }

    [ContextMenu("Move Right")]
    void MoveRight()
    {
        transform.position += Vector3.right;
    }

    #region Context menu region
#if UNITY_EDITOR //To avoid errors during the build
    [CustomEditor(typeof(Script_ContextMenuButton))]
    public class ContextMenuButton : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            Script_ContextMenuButton _component = (Script_ContextMenuButton)target;
            MethodInfo[] _methods = typeof(Script_ContextMenuButton).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (MethodInfo _method in _methods)
            {
                var _attributes = _method.GetCustomAttributes(typeof(ContextMenu), false);

                if (_attributes.Length > 0)
                {
                    var _contextMenu = _attributes[0] as ContextMenu;

                    if (GUILayout.Button(_contextMenu.menuItem))
                    {
                        _method.Invoke(_component, null);
                    }
                }
            }
        }
    }
#endif
    #endregion
}