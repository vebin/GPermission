import React, { Component } from 'react';
import { Table, Button, Modal, Form, Input, Icon, message } from 'antd';

const FormItem = Form.Item;
const confirm = Modal.confirm;

const data = [{
  key: '1',
  name: '测试系统',
  code: 'testcode',
  createDate: '2016-3-14 15:07',
  state: '正常',
  remark: '暂无备注',
}, {
  key: '2',
  name: '测试系统',
  code: 'testcode',
  createDate: '2016-3-14 15:07',
  state: '正常',
  remark: '暂无备注',
}, {
  key: '3',
  name: '测试系统',
  code: 'testcode',
  createDate: '2016-3-14 15:07',
  state: '正常',
  remark: '暂无备注',
}, {
  key: '4',
  name: '测试系统',
  code: 'testcode',
  createDate: '2016-3-14 15:07',
  state: '正常',
  remark: '暂无备注',
}];

class AppManager extends Component {
  constructor(props) {
    super(props);
    this.state = {
      modalVisable: false,
      modalModalTitle: '',
      modalLoading: false,
    };

    this.handleCreate = this.handleCreate.bind(this);
    this.handleUpdate = this.handleUpdate.bind(this);
    this.handleDelete = this.handleDelete.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleCancel = this.handleCancel.bind(this);
    this.renderAction = this.renderAction.bind(this);
  }
  getColumns() {
    return [{
      title: '应用系统名称',
      dataIndex: 'name',
      key: 'name',
      sorter(a, b) {
        return a > b;
      },
    }, {
      title: '应用系统代码',
      dataIndex: 'code',
      key: 'code',
    }, {
      title: '创建时间',
      dataIndex: 'createDate',
      key: 'createDate',
    }, {
      title: '状态',
      dataIndex: 'state',
      key: 'state',
    }, {
      title: '备注',
      dataIndex: 'remark',
      key: 'remark',
    }, {
      title: '操作',
      key: 'operation',
      render: this.renderAction,
    }];
  }
  handleCreate() {
    this.setState({
      modalModalTitle: '添加应用系统',
      modalVisable: true,
    });
  }
  handleUpdate(row) {
    const that = this;

    return () => {
      that.props.form.setFieldsValue(row);
      that.setState({
        modalModalTitle: '修改应用系统',
        modalVisable: true,
      });
    };
  }
  handleDelete() {
    confirm({
      title: '您是否确认要删除该应用系统',
      onOk() {
        const hide = message.loading('正在执行中...', 0);

        setTimeout(() => {
          message.success('操作成功');
          hide();
        }, 2500);
      },
    });
  }
  handleSubmit() {
    this.setState({ modalLoading: true });
    setTimeout(() => {
      this.setState({
        modalLoading: false,
        modalVisable: false,
      });
    }, 2000);
  }
  handleCancel() {
    this.setState({ modalVisable: false });
    this.props.form.resetFields();
  }
  renderAction(o, row) {
    return (
      <span>
        <Button className="mr-5" type="primary" onClick={this.handleUpdate(row)}>
          <Icon type="edit" />编辑
        </Button>
        <Button onClick={this.handleDelete}>
          <Icon type="delete" />删除
        </Button>
      </span>
    );
  }
  render() {
    const { getFieldProps } = this.props.form;
    const formItemLayout = {
      labelCol: { span: 6 },
      wrapperCol: { span: 14 },
    };

    const nameProps = getFieldProps('name', {
      rules: [
        { required: true, type: 'string', min: 1, message: '请输入系统名称' },
      ],
      trigger: ['onBlur', 'onChange'],
    });

    return (
      <div>
        <div className="mb-15">
          <Button type="primary" onClick={this.handleCreate}>添加应用系统</Button>
        </div>
        <Table columns={this.getColumns()} dataSource={data} />
        <Modal
          visible={this.state.modalVisable}
          title={this.state.modalModalTitle}
          onSubmit={this.handleSubmit}
          onCancal={this.handleCancel}
          footer={[
            <Button
              key="cancel"
              type="ghost"
              size="large"
              onClick={this.handleCancel}
            >
                取消
            </Button>,
            <Button
              key="submit"
              type="primary"
              size="large"
              loading={this.state.modalLoading}
              onClick={this.handleSubmit}
            >
                提交
            </Button>,
          ]}
        >
          <Form horizontal onSubmit={this.handleSubmit}>
            <FormItem label="应用系统名称：" {...formItemLayout} hasFeedback>
              <Input
                type="input"
                name="name"
                placeholder="请输入名称"
                {...nameProps}
                {...getFieldProps('name')}
              />
            </FormItem>
            <FormItem label="应用系统备注：" {...formItemLayout}>
              <Input
                type="textarea"
                name="remark"
                placeholder="请输入备注"
                {...getFieldProps('remark')}
              />
            </FormItem>
          </Form>
        </Modal>
      </div>
    );
  }
}

AppManager.propTypes = {
  form: React.PropTypes.object,
};

AppManager = Form.create()(AppManager);

export default AppManager;
