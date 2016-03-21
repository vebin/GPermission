import React, { Component } from 'react';
import { Table, Button, Icon, Form, Select, Input, Modal, message } from 'antd';
import AppModalForm from '../component/AppModalForm';

const confirm = Modal.confirm;
const { Item: FormItem } = Form;

const data = [{
  key: 1,
  account: 'admin',
  type: 1,
  password: 123456,
  createTime: '2012-2-3',
  state: '状态',
  deleteFlag: false,
  remark: '暂无备注',
}, {
  key: 2,
  account: 'guest',
  type: 1,
  password: 123456,
  createTime: '2012-2-3',
  state: '状态',
  deleteFlag: false,
  remark: '暂无备注',
}];

class AccountManager extends Component {
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
      title: '账号',
      dataIndex: 'account',
      key: 'account',
    }, {
      title: '类型',
      dataIndex: 'type',
      key: 'type',
    }, {
      title: '状态',
      dataIndex: 'state',
      key: 'state',
    }, {
      title: '创建时间',
      dataIndex: 'createTime',
      key: 'createTime',
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
      modalVisable: true,
      modalModalTitle: '添加用户',
    });
  }

  handleUpdate(row) {
    const that = this;
    return () => {
      that.props.form.setFieldsValue(row);
      that.setState({
        modalModalTitle: '编辑用户',
        modalVisable: true,
      });
    };
  }

  handleSubmit() {
    this.props.form.validateFields((errors, values) => {
      if (!!errors) {
        return;
      }
      console.log(values);
      this.setState({ modalLoading: true });
      setTimeout(() => {
        this.setState({
          modalLoading: false,
          modalVisable: false,
        });
        this.props.form.resetFields();
      }, 2000);
    });
  }

  handleCancel() {
    this.props.form.resetFields();
    this.setState({ modalVisable: false });
  }

  handleDelete() {
    confirm({
      title: '确认删除该用户？',
      onOk() {
        const hide = message.loading('正在执行中', 0);

        setTimeout(() => {
          hide();
          message.success('操作成功');
        }, 1000);
      },
    });
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

    return (
      <div>
        <Button
          className="mb-15"
          type="primary"
          size="large"
          onClick={this.handleCreate}
        >
          <Icon type="plus" />添加帐号
        </Button>
        <Table columns={this.getColumns()} dataSource={data} />
        <AppModalForm
          modalVisable={this.state.modalVisable}
          modalModalTitle={this.state.modalModalTitle}
          modalLoading={this.state.modalLoading}
          handleSubmit={this.handleSubmit}
          handleCancel={this.handleCancel}
        >
          <Form horizontal onSubmit={this.handleSubmit}>
            <FormItem label="帐号名称：" {...formItemLayout} hasFeedback>
              <Input
                type="input"
                name="account"
                placeholder="请输入帐号名称"
                {...getFieldProps('account')}
              />
            </FormItem>
            <FormItem label="类型：" {...formItemLayout}>
              <Select
                defaultValue="1"
                style={{ width: 120 }}
                name="type"
                {...getFieldProps('type')}
              >
                <Select.Option value="1">Easy</Select.Option>
                <Select.Option value="2">Normal</Select.Option>
                <Select.Option value="3">Hard</Select.Option>
              </Select>
            </FormItem>
            <FormItem label="密码：" {...formItemLayout} hasFeedback>
              <Input
                type="input"
                name="password"
                placeholder="请输入密码"
                {...getFieldProps('password')}
              />
            </FormItem>
            <FormItem label="备注：" {...formItemLayout} hasFeedback>
              <Input
                type="textarea"
                name="remark"
                placeholder="请输入备注"
                {...getFieldProps('remark')}
              />
            </FormItem>
          </Form>
        </AppModalForm>
      </div>
    );
  }
}

AccountManager.propTypes = {
  form: React.PropTypes.object,
};

AccountManager = Form.create()(AccountManager);

export default AccountManager;
