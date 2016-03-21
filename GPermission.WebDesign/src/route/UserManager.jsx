import React, { Component } from 'react';
import { Table, Button, Icon, Form, Input, Modal, message, TreeSelect } from 'antd';
import AppModalForm from '../component/AppModalForm';

const confirm = Modal.confirm;
const { Item: FormItem } = Form;
const SHOW_PARENT = TreeSelect.SHOW_PARENT;

const treeData = [{
  label: '节点一',
  value: '0-0',
  key: '0-0',
  children: [{
    label: '子节点一',
    value: '0-0-0',
    key: '0-0-0',
  }, {
    label: '子节点二',
    value: '0-0-1',
    key: '0-0-1',
  }],
}, {
  label: '节点二',
  value: '0-1',
  key: '0-1',
  children: [{
    label: '子节点三',
    value: '0-1-0',
    key: '0-1-0',
  }, {
    label: '子节点四',
    value: '0-1-1',
    key: '0-1-1',
  }],
}];

const data = [{
  key: 1,
  account: 'admin',
  userCode: 1,
  type: 1,
  systemId: 1,
  state: '状态',
  deleteFlag: false,
  remark: '暂无备注',
}, {
  key: 2,
  account: 'guest',
  userCode: 1,
  type: 1,
  systemId: 1,
  state: '状态',
  deleteFlag: false,
  remark: '暂无备注',
}];

class UserManager extends Component {
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
      title: '用户账户',
      dataIndex: 'account',
      key: 'account',
    }, {
      title: '用户代码',
      dataIndex: 'userCode',
      key: 'userCode',
    }, {
      title: '状态',
      dataIndex: 'state',
      key: 'state',
    }, {
      title: '备注',
      dataIndex: 'remark',
      key: 'remark',
    }, {
      title: '角色',
      key: 'role',
      render: () => {
        const tProps = {
          treeData,
          value: this.state.value,
          onChange: this.onChange,
          multiple: true,
          treeCheckable: true,
          showCheckedStrategy: SHOW_PARENT,
          searchPlaceholder: '请选择',
          style: {
            width: 300,
          },
        };
        return <TreeSelect {...tProps} />;
      },
    }, {
      title: '应用系统',
      key: 'app',
      render: () => {
        const tProps = {
          treeData,
          value: this.state.value,
          onChange: this.onChange,
          multiple: true,
          treeCheckable: true,
          showCheckedStrategy: SHOW_PARENT,
          searchPlaceholder: '请选择',
          style: {
            width: 300,
          },
        };
        return <TreeSelect {...tProps} />;
      },
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

UserManager.propTypes = {
  form: React.PropTypes.object,
};

UserManager = Form.create()(UserManager);

export default UserManager;
