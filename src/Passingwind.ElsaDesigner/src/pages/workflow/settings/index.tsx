import {
    getWorkflowSettingsCleanup,
    updateWorkflowSettingsCleanup,
} from '@/services/WorkflowSettings';
import type { ProFormInstance } from '@ant-design/pro-components';
import {
    PageContainer,
    ProCard,
    ProForm,
    ProFormCheckbox,
    ProFormDependency,
    ProFormDigit,
    ProFormSwitch,
} from '@ant-design/pro-components';
import { Col, message, Row, Space, Spin } from 'antd';
import React, { useRef, useState } from 'react';
import { useAccess, useIntl } from 'umi';

const Index: React.FC = () => {
    const intl = useIntl();
    const form = useRef<ProFormInstance>();

    const [loading, setLoading] = useState<boolean>(false);

    const handleSubmit = async (values: any) => {
        setLoading(true);
        const result = await updateWorkflowSettingsCleanup(values);
        setLoading(false);
        if (result?.response?.ok) {
            message.success(intl.formatMessage({ id: 'common.dict.save.success' }));
            return true;
        }
        return false;
    };

    return (
        <PageContainer>
            <ProCard
                tabs={{
                    items: [
                        {
                            key: 'cleanup',
                            label: intl.formatMessage({
                                id: 'page.workflow.settings.cleanup',
                            }),
                            children: (
                                <Spin spinning={loading}>
                                    <ProForm
                                        formRef={form}
                                        layout="horizontal"
                                        labelWrap
                                        labelCol={{ span: 4 }}
                                        submitter={{
                                            render: (props, doms) => {
                                                return (
                                                    <Row>
                                                        <Col offset={3}>
                                                            <Space>{doms}</Space>
                                                        </Col>
                                                    </Row>
                                                );
                                            },
                                        }}
                                        request={async () => {
                                            return await getWorkflowSettingsCleanup();
                                        }}
                                        onFinish={async (values) => handleSubmit(values)}
                                    >
                                        <ProFormSwitch
                                            label={intl.formatMessage({
                                                id: 'page.workflow.settings.cleanup.enabled',
                                            })}
                                            name="enabled"
                                        />
                                        <ProFormDigit
                                            label={intl.formatMessage({
                                                id: 'page.workflow.settings.cleanup.keepDays',
                                            })}
                                            name="keepDays"
                                            rules={[{ required: true }]}
                                            width="sm"
                                        />
                                        <ProFormCheckbox
                                            label={intl.formatMessage({
                                                id: 'page.workflow.settings.cleanup.scopeAll',
                                            })}
                                            name="scopeAll"
                                            width="md"
                                        />
                                        <ProFormDependency name={['scopeAll']}>
                                            {({ scopeAll }) => {
                                                return (
                                                    !scopeAll && (
                                                        <ProFormCheckbox.Group
                                                            label={intl.formatMessage({
                                                                id: 'page.workflow.settings.cleanup.scopes',
                                                            })}
                                                            name="scopes"
                                                            options={[
                                                                { label: 'Input', value: 1 },
                                                                { label: 'Output', value: 2 },
                                                                { label: 'Faults', value: 4 },
                                                                { label: 'Variables', value: 8 },
                                                                { label: 'Metadata', value: 16 },
                                                                {
                                                                    label: 'Activity Scopes',
                                                                    value: 32,
                                                                },
                                                                {
                                                                    label: 'Activity Data',
                                                                    value: 64,
                                                                },
                                                                {
                                                                    label: 'Execution Logs',
                                                                    value: 128,
                                                                },
                                                            ]}
                                                        />
                                                    )
                                                );
                                            }}
                                        </ProFormDependency>
                                    </ProForm>
                                </Spin>
                            ),
                        },
                    ],
                }}
            />
        </PageContainer>
    );
};

export default Index;
