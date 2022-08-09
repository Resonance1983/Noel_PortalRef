using UnityEngine;

public class FindTools : MonoBehaviour {

    /// <summary>
    /// transform���͵ݹ����������
    /// </summary>
    /// <returns>������Ҫ���ҵ�������.</returns>
    /// <param name="parent">�������.</param>
    /// <param name="targetName">��Ҫ���ҵ�����������.</param>
    public static Transform FindChild(Transform parent, string targetName) {
        Transform target = parent.Find(targetName);
        //����ҵ���ֱ�ӷ���
        if (target != null)
            return target;
        //���û��û���ҵ���˵��û���ڸ��Ӳ㼶�����ȱ����ò㼶����transform��Ȼ��ͨ���ݹ��������----�ٴε��ø÷���
        for (int i = 0; i < parent.childCount; i++) {
            //ͨ���ٴε��ø÷����ݹ���һ�㼶������
            target = FindChild(parent.GetChild(i), targetName);

            if (target != null)
                return target;
        }
        return target;
    }


    /// <summary>
    /// ���Ͳ���
    /// </summary>
    /// <returns>������Ҫ���ҵ������������.</returns>
    /// <param name="parent">�������.</param>
    /// <param name="targetName">��Ҫ���ҵ�����������.</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public static T FindChildComponent<T>(Transform parent, string targetName) where T : Component {
        Transform target = parent.Find(targetName);
        if (target != null) {
            return target.GetComponent<T>();
        }
        for (int i = 0; i < parent.childCount; i++) {
            target = FindChild(parent.GetChild(i), targetName);
            if (target != null) {
                return target.GetComponent<T>();
            }
        }
        return target.GetComponent<T>();
    }

}
