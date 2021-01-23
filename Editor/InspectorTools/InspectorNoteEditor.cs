using UnityEditor;
using UnityEngine;

namespace GGUnityUtilityEditor
{
    [CustomEditor(typeof(InspectorNote))]
    public class InspectorNoteEditor : Editor
    {
        #region GUI

        public override void OnInspectorGUI()
        {
            // Get note
            InspectorNote note = (InspectorNote)target;
            
            //
            if (note.IsEditing)
            {
                OnDrawNoteEditMode(note);
            }
            else
            {
                OnDrawDisplayMode(note);
            }
            
            // Button
            OnDrawSwitchModeButton(note);
        }

        private static void OnDrawNoteEditMode(InspectorNote note)
        {
            // Title
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Note Title:");
            note.NoteTitle = GUILayout.TextField(note.NoteTitle);
            EditorGUILayout.Space();
            
            // Title options
            EditorGUILayout.LabelField("Show Title?");
            note.ShowTitle = EditorGUILayout.Toggle(note.ShowTitle);
            EditorGUILayout.Space();
            EditorGUILayout.Space();
                
            // Body
            EditorGUILayout.LabelField("Note Body:");
            note.NoteBody = GUILayout.TextArea(note.NoteBody);
        }

        private static void OnDrawDisplayMode(InspectorNote note)
        {
            EditorGUILayout.Space();
            
            // Title
            if (note.ShowTitle)
            {
                var titleStyle = new GUIStyle(GUI.skin.label) 
                    {
                        alignment = TextAnchor.MiddleCenter, 
                        fontStyle = FontStyle.Bold,
                        fontSize = 14
                    };
                EditorGUILayout.LabelField(note.NoteTitle, titleStyle, GUILayout.ExpandWidth(true)); 
                EditorGUILayout.Space();
            }
            
            // Body
            EditorGUILayout.Space();
            var bodyStyle = new GUIStyle(GUI.skin.textArea) 
            {
                richText = true,
                clipping = TextClipping.Overflow,
                fontSize = 13
            };
            EditorGUILayout.LabelField(note.NoteBody + "\n",  bodyStyle);
        }

        private static void OnDrawSwitchModeButton(InspectorNote note)
        {
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            string buttonLabel = note.IsEditing ? "Stop Editing" : "Edit";
            if (GUILayout.Button(buttonLabel))
            {
                note.IsEditing = !note.IsEditing;
            }
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }

        #endregion GUI
    }
}
