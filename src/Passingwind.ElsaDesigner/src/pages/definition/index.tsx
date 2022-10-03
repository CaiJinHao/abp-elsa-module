import {
    deleteWorkflowDefinition,
    getWorkflowDefinitionList,
    getWorkflowDefinitionVersion,
    updateWorkflowDefinitionDefinition,
    workflowDefinitionDispatch,
    workflowDefinitionPublish,
    workflowDefinitionUnPublish,
} from '@/services/WorkflowDefinition';
import { ModalForm, ProFormSelect, ProFormText, ProFormTextArea } from '@ant-design/pro-form';
import { PageContainer } from '@ant-design/pro-layout';
import type { ActionType, ProColumnType } from '@ant-design/pro-table';
import { TableDropdown } from '@ant-design/pro-table';
import ProTable from '@ant-design/pro-table';
import { Button, Form, message, Modal } from 'antd';
import React, { useRef, useState } from 'react';
import { formatMessage, useHistory, useIntl } from 'umi';
import EditFormItems from './edit-form-items';
import type { API } from '@/services/typings';

const handleEdit = async (id: string, data: any) => {
    const response = await updateWorkflowDefinitionDefinition(id, data);
    if (response) {
        message.success(formatMessage({ id: 'common.dict.modified.success' }));
        return true;
    }
    return false;
};

const handleDelete = async (id: string) => {
    const response = await deleteWorkflowDefinition(id);
    if (response?.response?.ok) {
        message.success(formatMessage({ id: 'common.dict.deleted.success' }));
        return true;
    }
    return false;
};

const Index: React.FC = () => {
    const actionRef = useRef<ActionType>();
    const intl = useIntl();

    const history = useHistory();

    const [actionRow, setActionRow] = useState<API.WorkflowDefinition>();

    const [editModalVisible, setEditModalVisible] = useState<boolean>(false);
    const [editModalTitle, setEditModalTitle] = useState<string>('');
    const [editModalData, setEditModalData] = useState<API.WorkflowDefinition>();
    const [editModalDataId, setEditModalDataId] = useState<string>();

    const [dispatchFormVisible, setDispatchFormVisible] = useState<boolean>(false);
    const [dispatchId, setDispatchId] = useState<string>();

    // const [searchKey, setSearchKey] = useState<string>();

    const [editForm] = Form.useForm();

    const columns: ProColumnType<API.WorkflowDefinition>[] = [
        {
            dataIndex: 'filter',
            title: intl.formatMessage({ id: 'page.definition.field.name' }),
            hideInTable: true,
        },
        {
            dataIndex: 'name',
            title: intl.formatMessage({ id: 'page.definition.field.name' }),
            search: false,
            copyable: true,
        },
        {
            dataIndex: 'displayName',
            title: intl.formatMessage({ id: 'page.definition.field.displayName' }),
            search: false,
            copyable: true,
        },
        {
            dataIndex: 'description',
            title: intl.formatMessage({ id: 'page.definition.field.description' }),
            search: false,
        },
        {
            dataIndex: 'latestVersion',
            title: intl.formatMessage({ id: 'page.definition.field.latestVersion' }),
            search: false,
        },
        {
            dataIndex: 'publishedVersion',
            title: intl.formatMessage({ id: 'page.definition.field.publishedVersion' }),
            search: false,
        },
        {
            dataIndex: 'isSingleton',
            title: intl.formatMessage({ id: 'page.definition.field.isSingleton' }),
            search: false,
            valueEnum: {
                true: { text: 'Y' },
                false: { text: 'N' },
            },
        },
        {
            dataIndex: 'creationTime',
            title: intl.formatMessage({ id: 'common.dict.lastModificationTime' }),
            valueType: 'dateTime',
            search: false,
            renderText: (_, record) => {
                return record.lastModificationTime ?? record.creationTime;
            },
        },
        {
            title: intl.formatMessage({ id: 'common.dict.table-action' }),
            valueType: 'option',
            width: 200,
            align: 'center',
            render: (text, record, _, action) => [
                <a
                    key="dispatch"
                    onClick={() => {
                        setDispatchId(record.id);
                        setActionRow(record);
                        setDispatchFormVisible(true);
                    }}
                >
                    {intl.formatMessage({
                        id: 'page.definition.dispatch',
                    })}
                </a>,
                <a
                    key="edit"
                    onClick={() => {
                        setEditModalData(
                            Object.assign({}, record, {
                                variablesString: JSON.stringify(record.variables ?? {}),
                            }),
                        );
                        setEditModalDataId(record.id);
                        setEditModalVisible(true);
                        setEditModalTitle(
                            `${intl.formatMessage({ id: 'common.dict.edit' })} ${record.name}`,
                        );
                    }}
                >
                    {intl.formatMessage({ id: 'page.definition.settings' })}
                </a>,
                <a
                    key="designer"
                    onClick={() => {
                        history.push('/designer?id=' + record.id);
                    }}
                >
                    {intl.formatMessage({
                        id: 'page.definition.designer',
                    })}
                </a>,
                <TableDropdown
                    key="actionGroup"
                    onSelect={async (key) => {
                        if (key == 'delete') {
                            Modal.confirm({
                                title: 'Confirm delete?',
                                onOk: async () => {
                                    if (await handleDelete(record.id!)) {
                                        action?.reload();
                                    }
                                },
                            });
                        } else if (key == 'publish') {
                            if (await workflowDefinitionPublish(record.id!)) {
                                action?.reload();
                            }
                        } else if (key == 'unpublish') {
                            if (await workflowDefinitionUnPublish(record.id!)) {
                                action?.reload();
                            }
                        }
                    }}
                    menus={[
                        {
                            key: 'publish',
                            name: intl.formatMessage({ id: 'page.definition.publish' }),
                            disabled: record.publishedVersion != null,
                        },
                        {
                            key: 'unpublish',
                            name: intl.formatMessage({ id: 'page.definition.unpublish' }),
                            disabled: record.publishedVersion == null,
                        },
                        { key: 'delete', name: intl.formatMessage({ id: 'common.dict.delete' }) },
                    ]}
                />,
            ],
        },
    ];

    return (
        <PageContainer>
            <ProTable<API.WorkflowDefinition>
                columns={columns}
                actionRef={actionRef}
                rowKey="id"
                toolBarRender={() => [
                    <Button
                        key="add"
                        type="primary"
                        onClick={() => {
                            history.push('/designer');
                        }}
                    >
                        {intl.formatMessage({ id: 'common.dict.create' })}
                    </Button>,
                ]}
                search={{ labelWidth: 120 }}
                request={async (params) => {
                    const { current, pageSize } = params;
                    delete params.current;
                    delete params.pageSize;
                    const skipCount = (current! - 1) * pageSize!;
                    const result = await getWorkflowDefinitionList({
                        ...params,
                        skipCount,
                        maxResultCount: pageSize,
                    });
                    if (result)
                        return {
                            success: true,
                            data: result.items,
                            total: result.totalCount,
                        };
                    else {
                        return {
                            success: false,
                        };
                    }
                }}
            />

            {/*  */}
            <ModalForm
                layout="horizontal"
                form={editForm}
                preserve={false}
                labelCol={{ span: 5 }}
                width={650}
                labelWrap
                title={editModalTitle}
                visible={editModalVisible}
                modalProps={{ destroyOnClose: true, maskClosable: false }}
                onVisibleChange={setEditModalVisible}
                initialValues={editModalData}
                onValuesChange={(value) => {
                    if (value.displayName) {
                        editForm.setFieldsValue({
                            name: value.displayName?.replaceAll(' ', '-'),
                        });
                    }
                }}
                onFinish={async (value) => {
                    const success = await handleEdit(
                        editModalDataId!,
                        Object.assign(
                            {},
                            editModalData,
                            { variables: JSON.parse(value.variablesString ?? '{}') },
                            value,
                        ),
                    );

                    if (success) {
                        setEditModalVisible(false);
                        actionRef.current?.reload();
                    }
                }}
            >
                <EditFormItems />
            </ModalForm>

            {/*  */}
            <ModalForm
                layout="horizontal"
                preserve={false}
                labelCol={{ span: 5 }}
                width={600}
                labelWrap
                title={intl.formatMessage({
                    id: 'page.definition.dispatch',
                })}
                visible={dispatchFormVisible}
                modalProps={{ destroyOnClose: true, maskClosable: false }}
                onVisibleChange={setDispatchFormVisible}
                onFinish={async (value) => {
                    const result = await workflowDefinitionDispatch(dispatchId!, value);
                    if (result?.workflowInstanceId) {
                        message.success(
                            intl.formatMessage(
                                {
                                    id: 'page.definition.dispatch.success',
                                },
                                { id: result.workflowInstanceId },
                            ),
                        );
                        return true;
                    }
                    return false;
                }}
            >
                <ProFormSelect
                    label={intl.formatMessage({ id: 'page.definition.dispatch.activityId' })}
                    name="activityId"
                    request={async () => {
                        const result = await getWorkflowDefinitionVersion(
                            dispatchId!,
                            actionRow?.publishedVersion ?? 1,
                        );
                        return (result.activities ?? []).map((x) => {
                            return {
                                label: `${x.displayName} (${x.name})`,
                                value: x.activityId,
                            };
                        });
                    }}
                />
                <ProFormText
                    label={intl.formatMessage({ id: 'page.definition.dispatch.correlationId' })}
                    name="correlationId"
                    rules={[{ max: 36 }]}
                />
                <ProFormText
                    label={intl.formatMessage({ id: 'page.definition.dispatch.contextId' })}
                    name="contextId"
                    rules={[{ max: 36 }]}
                />
                <ProFormTextArea
                    label={intl.formatMessage({ id: 'page.definition.dispatch.input' })}
                    name="input"
                    fieldProps={{
                        autoSize: {
                            minRows: 2,
                            maxRows: 10,
                        },
                    }}
                />
            </ModalForm>
        </PageContainer>
    );
};

export default Index;
